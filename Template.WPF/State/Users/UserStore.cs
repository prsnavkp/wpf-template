﻿using Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.WPF.State.Users
{
    public class UserStore : IUserStore
    {
        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}