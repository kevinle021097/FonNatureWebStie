﻿using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IContactAdminRepository
    {
        Contact GetContact();
        bool EditContact(Contact contact);
    }
}
