using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAuthentication.ViewModel;

namespace WebAuthentication.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }
        public readonly SignInManager<IdentityUser> signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl=null)
        {
            if (ModelState.IsValid)
            {
             
                var identityResult=await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "Username or Password INCORECT");
            }
            return Page();
        }
    }
}
