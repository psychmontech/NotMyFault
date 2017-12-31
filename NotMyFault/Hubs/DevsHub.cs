using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Hubs
{
    public class DevsHub : Hub
    {
        public IDevRepo _devRepo { get; set; }
        public IProjRepo _projRepo { get; set; }
        public IInterConverRepo _interConverRepo { get; set; }
        private readonly ILogger _logger;
        public DevsHub(IDevRepo devRepo, IProjRepo projRepo, ILogger<DevsHub> logger,
                       IInterConverRepo interConverRepo)
        {
            _devRepo = devRepo;
            _logger = logger;
            _projRepo = projRepo;
            _interConverRepo = interConverRepo;
        }
        public Task SendToAll(string message)
        {
            //_logger.LogCritical(1002, "$$$$$$$$ project id = {ID}", userId);
            return Clients.All.InvokeAsync("Send", message);
        }
        public async Task JoinGroup(string groupName, string UserNickName)
        {
            await Groups.AddAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).InvokeAsync("Send", "-- " + UserNickName + " joined --");
        }

        public async Task LeaveGroup(string groupName, string UserNickName)
        {
            await Groups.RemoveAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).InvokeAsync("Send", "-- " + UserNickName + " left --");
        }

        public Task SendToGroup(string groupName, string message, int projId, int userId, string userNickName)
        {
            Project proj = _projRepo.GetProjById(projId);
            InterConverEntry interConverEntry = new InterConverEntry
            {
                MyProj = proj,
                ByDevId = userId,
                DevNickName = userNickName,
                Timestamp = DateTime.Now,
                Text = message
            };
            _interConverRepo.AddEntry(interConverEntry);
            return Clients.Group(groupName).InvokeAsync("Send", userNickName + ": " + message);
        }
    }
}
