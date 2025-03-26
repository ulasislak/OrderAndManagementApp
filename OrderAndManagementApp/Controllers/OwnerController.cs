using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.OwnerDto;
using Microsoft.AspNetCore.Mvc;
using OrderAndManagementApp.ViewModel;

namespace OrderAndManagementApp.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService,IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Mail,string Password)
        {
            var GetAllOwner=await _ownerService.GetAllOwner();
            var LoginControl = GetAllOwner.FirstOrDefault(x => x.Mail == Mail && x.Password == Password);
            if (LoginControl!= null)
            {
                return RedirectToAction("Dashboard");
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(OwnerVM ownerVM)
        {
            await _ownerService.AddUser(_mapper.Map<OwnerDto>(ownerVM));
            var OwnerControl = (await _ownerService.GetAllOwner()).FirstOrDefault(x => x.Mail == ownerVM.Mail && x.Password == ownerVM.Password);
            if (OwnerControl!= null)
            {
                return RedirectToAction("Dashboard");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
       
    }
}
