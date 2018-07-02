﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine
{
    public interface IUser
    {
        void SetName(string name);
    
        string Name();

        void SetProfile(List<string> profile);

        List<string> Profile();
    }
}
