using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestSupportApp.Models;
using RequestSupportApp.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RequestSupportApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RequestSupportAppContext _context;

        public HomeController(ILogger<HomeController> logger, RequestSupportAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Retrieves list of all Tickets
            var retrieveTicketList = _context.Ticket.ToListAsync();
            List<Ticket> ticketList = await retrieveTicketList;
            //Passes ticket list to view
            ViewBag.ticketList = ticketList;

            //Creates a list to store only the unique project name
            List<string> uniqueProjList = new List<string>();

            foreach (var ticket in ticketList)
            {

                    if (!uniqueProjList.Contains(ticket.ProjectName))
                    {
                    //If project name is unique, add to list
                        uniqueProjList.Add(ticket.ProjectName);
                    }
            }
            //Creates a list to store the # of tickets for each unique project
            List<int> projCountList = new List<int>();
            for(int i=0; i < uniqueProjList.Count; i++) { projCountList.Add(0); }
            foreach (var ticket in ticketList)
            {
                //Adds 1 each time a ticket for a project appears in main ticketList
                int pos = uniqueProjList.IndexOf(ticket.ProjectName);
                projCountList[pos]++;
            }
            //Assigns the total # of tickets to totalTickets variable
            var totalTickets = ticketList.Count;

            //Passes both lists and total # of tickets to view for the graph construction
            ViewBag.uniqueProjList = uniqueProjList;
            ViewBag.projCountList = projCountList;
            ViewBag.totalTickets = totalTickets;

            return View(await _context.Ticket.ToListAsync());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
