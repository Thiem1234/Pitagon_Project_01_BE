﻿using API_Project01.Business;
using API_Project01.Model;
namespace API_Project01.Factory
{
    interface IConvertFactory
    {
        IConverter createConvert();  
    }
}
