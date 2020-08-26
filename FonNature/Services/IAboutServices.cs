﻿using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IAboutServices
    {
        About GetAbout(int id);
        List<About> GetAboutsTestimonials();
        About GetAboutMain();
        List<Staff> GetStaffs();
        SEO GetSeo();
        Banner GetBanner();
    }
}
