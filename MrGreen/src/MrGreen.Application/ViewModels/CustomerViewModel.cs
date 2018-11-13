﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MrGreen.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PersonalNumber { get; set; }
    }
}
