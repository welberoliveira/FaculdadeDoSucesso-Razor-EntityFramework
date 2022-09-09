using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Resources;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Descrição")]
        public string Name { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Orçamento Disponível (R$)")]
        [Required(ErrorMessage = "O valor para o Orçamento está incorreto.")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Início")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Cordenador")]
        public int? InstructorID { get; set; }

        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }

        [Display(Name = "Coordenador")]
        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}