using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;

namespace ProvaDesenvolvimento.Models
{
    public class UserViewModel
    {
        [Key]
        [DataType(DataType.Text)]
        public String Id { get; set; }
        
        [Required(ErrorMessage = "O campo '{0}' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo '{0}' deve possuir, no máximo, {1} caracteres.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo '{0}' deve possuir, no máximo, {1} caracteres.")]
        [DataType(DataType.Text)]
        [Display(Name = "Sobrenome")]
        public String LastName { get; set; }

        [StringLength(100, ErrorMessage = "O campo '{0}' deve possuir, no máximo, {1} caracteres.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public String BirthDate { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo '{0}' deve possuir, no mínimo, 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de Senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public String ConfirmPassword { get; set; }
    }
}