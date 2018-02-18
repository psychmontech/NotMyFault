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
            List<int> acceptCurrency = new List<int>();
            if (cryptcurValue.AcceptBitcoid) acceptCurrency.Add(Cryptocurrency.Bitcoin);
            if (cryptcurValue.AcceptEthereum) acceptCurrency.Add(Cryptocurrency.Ethereum);
            if (cryptcurValue.AcceptLitecoin) acceptCurrency.Add(Cryptocurrency.Litecoin);

            MakeAnOfferViewModel makeAnOfferViewModel = new MakeAnOfferViewModel
            {
                ProjId = projId,
                BuyerId = buyerId,
                AcceptCurrency = acceptCurrency
            };
            return View(makeAnOfferViewModel);
        }
        [HttpPost]
        public IActionResult MakeAnOffer(MakeAnOfferViewModel makeAnOfferViewModel)
        {
            if (ModelState.IsValid)
            {
                int projId = makeAnOfferViewModel.ProjId;
                Offer offer = new Offer
                {
                    MyProj = _projRepo.GetProjById(projId),
                    Value = makeAnOfferViewModel.Value,
                    Currency = makeAnOfferViewModel.Currency,
                    BuyerId = makeAnOfferViewModel.BuyerId
                };
                _transRepo.AddAnOfferToProj(offer, projId);
                return RedirectToAction("Index", "Project", new { id = projId });
            }
            return View(makeAnOfferViewModel);
        }

        public IActionResult WithdrawAnOffer(int projId, int buyerId)
        {
            _transRepo.RemoveAnOffer(projId, buyerId);
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public ViewResult SeeOffers(int projId)
        {
            ICollection<Offer> offers = _transRepo.GetMyOffersByProjId(projId);
            ICollection<MakeAnOfferViewModel> offersViewModel = new List<MakeAnOfferViewModel>();
            foreach (var offer in offers)
            {
                offersViewModel.Add(new MakeAnOfferViewModel
                {
                    Buyer = _buyerRepo.GetBuyerById(offer.BuyerId),
                    BuyerId = offer.BuyerId,
                    Currency = offer.Currency,
                    Value = offer.Value,
                    ProjId = offer.MyProj.ProjectId
                });
            }
            return View(offersViewModel);
        }
    }
}
