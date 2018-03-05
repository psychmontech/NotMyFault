using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Constants;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class TransactionController : Controller
    {
        private readonly UserManager<User> _userManager;
        public ITransRepo _transRepo { get; set; }
        public IProjRepo _projRepo { get; set; }
        public IBuyerRepo _buyerRepo { get; set; }
        private readonly ILogger _logger;
        public TransactionController(UserManager<User> userManager, ITransRepo transRepo, ILogger<ProjectController> logger,
                                     IProjRepo ProjRepo, IBuyerRepo buyerRepo)
        {
            _userManager = userManager;
            _transRepo = transRepo;
            _projRepo = ProjRepo;
            _logger = logger;
            _buyerRepo = buyerRepo;
        }

        public ViewResult MakeAnOffer(int projId, int buyerId)
        {
            Project proj = _projRepo.GetProjById(projId);
            CryptcurValue cryptcurValue = _projRepo.GetValuationById(projId);
            bool thisBuyerHasPendingOffer = _transRepo.ThisBuyerHasPendingOffer(buyerId, projId);
            List<int> acceptCurrency = new List<int>();
            if (cryptcurValue.AcceptBitcoid) acceptCurrency.Add(Cryptocurrency.Bitcoin);
            if (cryptcurValue.AcceptEthereum) acceptCurrency.Add(Cryptocurrency.Ethereum);
            if (cryptcurValue.AcceptLitecoin) acceptCurrency.Add(Cryptocurrency.Litecoin);
            List<Offer> historyOffers = _transRepo.GetMyOffersByProjIdBuyerId(projId, buyerId).ToList();

            MakeAnOfferViewModel makeAnOfferViewModel = new MakeAnOfferViewModel
            {
                ProjId = projId,
                BuyerId = buyerId,
                AcceptCurrency = acceptCurrency,
                HistoryOffers = historyOffers,
                ThisProjHasPendingOffer = thisBuyerHasPendingOffer
            };
            return View(makeAnOfferViewModel);
        }
        [HttpPost]
        public IActionResult MakeAnOffer(MakeAnOfferViewModel makeAnOfferViewModel)
        {
            if (ModelState.IsValid)
            {
                int projId = makeAnOfferViewModel.ProjId;
                Project proj = _projRepo.GetProjById(projId);
                int buyerId = makeAnOfferViewModel.BuyerId;
                //you can make an offer when you already have, your last offer will be removed
                //therefore there is only one pending offer for one buyer at a time
                if (_transRepo.ThisBuyerHasPendingOffer(buyerId, projId)) WithdrawAnOffer(projId, buyerId);

                if (proj.TradingStatus != ProjStatus.Under_Offer) proj.TradingStatus = ProjStatus.Under_Offer;  //use AddAnOfferToProj below to saveChanges

                Offer offer = new Offer
                {
                    MyProj = _projRepo.GetProjById(projId),
                    Value = makeAnOfferViewModel.Value,
                    Currency = makeAnOfferViewModel.Currency,
                    BuyerId = buyerId,
                    Status = OfferStatus.Pending
                };
                _transRepo.AddAnOfferToProj(offer, projId);

                return RedirectToAction("MakeAnOffer", "Transaction", new { projId, buyerId });
            }
            return View(makeAnOfferViewModel);
        }

        public IActionResult WithdrawAnOffer(int projId, int buyerId)
        {
            Offer offer = _transRepo.GetPendingOfferByProjIdBuyerId(projId, buyerId);
            offer.Status = OfferStatus.Withdrawn;
            if (!_transRepo.GetMyPendingOffersByProjId(projId).Any())
            {
                Project proj = _projRepo.GetProjById(projId);
                proj.TradingStatus = ProjStatus.Under_Negotiation;
            }
            _transRepo.SaveChanges();
            return RedirectToAction("MakeAnOffer", "Transaction", new { projId, buyerId });
        }

        public ViewResult SeeOffers(int projId)
        {
            ICollection<Offer> offers = _transRepo.GetMyPendingOffersByProjId(projId);
            ICollection<MakeAnOfferViewModel> offersViewModel = new List<MakeAnOfferViewModel>();
            foreach (var offer in offers) if (offer.Status == OfferStatus.Pending)
            {
                offersViewModel.Add(new MakeAnOfferViewModel
                {
                    Buyer = _buyerRepo.GetBuyerById(offer.BuyerId),
                    BuyerId = offer.BuyerId,
                    Currency = offer.Currency,
                    Value = offer.Value,
                    ProjId = offer.MyProj.ProjectId,
                    OfferId = offer.OfferId
                });
            }
            return View(offersViewModel);
        }

        public IActionResult RejectAnOffer(int projId, int offerId)
        {
            Offer offer = _transRepo.FindOfferById(offerId);
            offer.Status = OfferStatus.Rejected;

            if (!_transRepo.GetMyPendingOffersByProjId(projId).Any())
                _projRepo.GetProjById(projId).TradingStatus = ProjStatus.Under_Negotiation;

            _transRepo.SaveChanges();
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public IActionResult AcceptAnOffer(int projId, int offerId)
        {
            Offer offer = _transRepo.FindOfferById(offerId);
            offer.Status = OfferStatus.Accepted;
            Project proj = _projRepo.GetProjById(projId);
            proj.TradingStatus = ProjStatus.In_Trade;
            _transRepo.SaveChanges();
            return RedirectToAction("Index", "Project", new { id = projId });
        }
    }
}
