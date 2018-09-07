using System;

namespace WebAPI.ViewModels
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
