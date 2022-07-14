/*
 * Created by: Richard Van Der Merwe
 * Reworked on: 10 July 2022
 * Copyright Holder: Varsity Collage until: 31 December 2022 / Then: Richard van der Merwe on: 1 January 2023
 * File: Interface IClassDefaults
 * Do not Replicate, work is for private use Only!
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHelper.Classes.Interfaces
{
    interface IClassDefaults
    {
        bool bIsActive { get; set; }
        bool bIsRenting { get; set; }
        void InitRun();
    }
}
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    * End of Class
    * -------------------------------------------------------------------------------------------------------------------------->
    */
