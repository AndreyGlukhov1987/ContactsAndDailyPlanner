using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactsAndDailyPlanner.BLL.DTOModels;
using ContactsAndDailyPlanner.BLL.Interfaces;
using ContactsAndDailyPlanner.Web.Common;
using ContactsAndDailyPlanner.Web.Models.Contact;
using ContactsAndDailyPlanner.Web.Models.Email;
using ContactsAndDailyPlanner.Web.Models.OtherContacInfo;
using ContactsAndDailyPlanner.Web.Models.Phone;
using ContactsAndDailyPlanner.Web.Models.Skype;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactsAndDailyPlanner.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactViewModel, ContactDTO>();
                cfg.CreateMap<EmailViewModel, EmailDTO>();
                cfg.CreateMap<PhoneViewModel, PhoneDTO>();
                cfg.CreateMap<SkypeViewModel, SkypeDTO>();
                cfg.CreateMap<OtherContactInfoViewModel, OtherContactInfoDTO>();
                cfg.CreateMap<ContactDTO, ContactViewModel>();
                cfg.CreateMap<EmailDTO, EmailViewModel>();
                cfg.CreateMap<PhoneDTO, PhoneViewModel>();
                cfg.CreateMap<SkypeDTO, SkypeViewModel>();
                cfg.CreateMap<OtherContactInfoDTO, OtherContactInfoViewModel>();
            }).CreateMapper();
        }
        // GET: Contact
        public ActionResult Index()
        {
            var viewModel = new ContactIndexViewModel();
            viewModel.Contacts = _mapper.Map<IEnumerable<ContactDTO>, IEnumerable<ContactViewModel>>(_contactService.GetContacts());
            return View(viewModel);
        }

        // GET: Contact/Details/5
        public ActionResult Details(Guid id)
        {
            ContactViewModel contact = null;
            if (id != Guid.Empty)
            {
                contact = _mapper.Map<ContactDTO, ContactViewModel>(_contactService.GetContact(id));
            }

            return PartialView(nameof(Details), contact);
        }

        // GET: Contact/Create
        public ActionResult CreateEdit(Guid id)
        {
            ContactViewModel contact = null;
            if (id != Guid.Empty)
            {
                contact = _mapper.Map<ContactDTO, ContactViewModel>(_contactService.GetContact(id));
            }

            if(contact == null)
                contact = new ContactViewModel();

            return PartialView(nameof(CreateEdit), contact);
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactViewModel contact)
        {
            if(ModelState.IsValid)
            {
                _contactService.Create(_mapper.Map<ContactViewModel, ContactDTO>(contact));
                return Ok();
            }

            return PartialView(nameof(CreateEdit),contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(_mapper.Map<ContactViewModel, ContactDTO>(contact));
            }

            return PartialView(nameof(CreateEdit), contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                _contactService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var viewModel = new ContactIndexViewModel();

            viewModel.Contacts = _mapper.Map<IEnumerable<ContactDTO>, IEnumerable<ContactViewModel>>(_contactService.Find(search));
            viewModel.Search = search;

            return View("Index", viewModel);
        }
    }
}