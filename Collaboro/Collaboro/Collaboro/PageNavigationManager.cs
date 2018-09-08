﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Collaboro
{
    public class PageNavigationManager
    {
        // Initialise Variables
        private static PageNavigationManager instance;
        private PageNavigationManager() { }
        private INavigation navigation;

        public static PageNavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        public INavigation Navigation
        {
            set { navigation = value; }
        }

        public void ShowFindTeamPage()
        {
            navigation.PushAsync(new FindTeam());
        }

        public void ShowBookMeetingPage()
        {
            navigation.PushAsync(new FindTeam()); // Needs updating
        }


    }
}
