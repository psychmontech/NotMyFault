using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;


namespace NotMyFault.Hubs
{
    public class NegoHub : Hub
    {
        public IDevRepo _devRepo { get; set; }
        public IProjRepo _projRepo { get; set; }
        public IBuyerRepo _buyerRepo { get; set; }
        public INegoRepo _negoRepo { get; set; }
        private readonly ILogger _logger;
        public NegoHub(IDevRepo devRepo, IProjRepo projRepo, ILogger<DevsHub> logger,
                       INegoRepo negoRepo, IBuyerRepo buyerRepo)
        {
            _devRepo = devRepo;
            _projRepo = projRepo;
            _buyerRepo = buyerRepo;
            _logger = logger;
            _negoRepo = negoRepo;
        }
        public Task SendToAll(string message)
        {
            //_logger.LogCritical(1002, "$$$$$$$$ project id = {ID}", userId);
            return Clients.All.InvokeAsync("Send", message);
        }
        public async Task JoinGroup(string groupName, string UserNickName)
        {
            await Groups.AddAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName, string UserNickName)
        {
            await Groups.RemoveAsync(Context.ConnectionId, groupName);
        }

        public Task SendToGroup(string groupName, string message, int projId, int userId, string userNickName)
        {
            _logger.LogCritical(1002, "$$$$$$$$ project id = {ID}", userId);
            Project proj = _projRepo.GetProjById(projId);
            Negotiation nego;
            int buyerId = Int32.Parse(groupName.Substring(groupName.LastIndexOf('-') + 1));
            if (_negoRepo.BuyerHasNegoWithProj(buyerId, projId) || userId != buyerId) 
            {
                nego = _negoRepo.GetNegoByBuyerProjId(buyerId, projId);
            }
            else
            {
                nego = new Negotiation
                {
                    MyProj = proj,
                    BuyerId = userId
                };
                _negoRepo.AddNego(nego);
            };

            NegoEntry negoEntry = new NegoEntry
            {
                MyNego = nego,
                UserId = userId,
                UserNickName = userNickName,
                Timestamp = DateTime.Now,
                Text = message,
            };
            _negoRepo.AddNegoEntry(negoEntry);
            return Clients.Group(groupName).InvokeAsync("Send", userNickName + ": " + message);
        }

    }
}
