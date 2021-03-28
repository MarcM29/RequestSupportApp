using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RequestSupportApp.Data;
using RequestSupportApp.Models;
using System.Threading;

namespace RequestSupportApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly RequestSupportAppContext _context;

        public TicketsController(RequestSupportAppContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {

            return View(await _context.Ticket.ToListAsync());
        }

        // GET: Tickets/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            var employeez = _context.Employee.ToListAsync();
            List<Employee> employees = await employeez;
            ViewBag.employeeList = employees;

            var retrieveTicketList = _context.Ticket.ToListAsync();
            List<Ticket> ticketList = await retrieveTicketList;
            ViewBag.ticketList = ticketList;

            return View(await _context.Ticket.ToListAsync());
        }

        // POST: Tickets/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String ProjName, String DepName, String EmpName, String SearchPhrase, String DateTime)
        {
            //Checks if no filter was chosen for each field
            if (ProjName is null)
            {
                ProjName = "";
            }
            if (DepName is null)
            {
                DepName = "";
            }
            if (EmpName is null)
            {
                EmpName = "";
            }
            if (SearchPhrase is null)
            {
                SearchPhrase = "";
            }
            if (DateTime is null)
            {
                DateTime = "";
            }
            ViewBag.ProjName = ProjName;
            ViewBag.DepName = DepName;
            ViewBag.EmpName = EmpName;
            ViewBag.SearchPhrase = SearchPhrase;
            ViewBag.DateTime = DateTime;

            return View("Index", await _context.Ticket.Where(j => (j.ProjectName.Contains(ProjName) && j.DepartmentName.Contains(DepName) && j.EmployeeName.Contains(EmpName) && j.ProjectDesc.Contains(SearchPhrase) && j.TicketDate.Contains(DateTime))).ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/DepSelect
        public async Task<IActionResult> DepSelect()
        {
            var employeez = _context.Employee.ToListAsync();
            List<Employee> employees = await employeez;

            ViewBag.employeeList = employees;
            return View();
        }

        // POST: Tickets/DepSelect AKA CREATE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  DepSelect(String DepartmentName)
        {
            var employeez = _context.Employee.ToListAsync();
            List<Employee> employees = await employeez;

            ViewBag.employeeList = employees;
            ViewBag.dep = DepartmentName;
            return View("Create");
        }

        // GET: Tickets/Create
        /*public async Task<IActionResult> Create(String DepartmentName)
        {
            var employeez = _context.Employee.ToListAsync();
            List<Employee> employees = await employeez;

            ViewBag.employeeList = employees;
            ViewBag.dep = DepartmentName;
            return View();
        }*/

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,DepartmentName,EmployeeName,ProjectDesc,TicketDate")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ShowSearchForm));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,DepartmentName,EmployeeName,ProjectDesc,TicketDate")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ShowSearchForm));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ShowSearchForm));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
