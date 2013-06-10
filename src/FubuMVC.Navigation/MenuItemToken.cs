﻿using System;
using System.Collections.Generic;
using FubuCore;

namespace FubuMVC.Navigation
{
    [Serializable]
    public class MenuItemToken
    {
        public MenuItemToken()
        {
            Url = string.Empty;
            Children = new MenuItemToken[0];
			Data = new Dictionary<string, object>();
        }

        public bool EnabledAndShown()
        {
            return MenuItemState.IsEnabled && MenuItemState.IsShown;
        }

        public MenuItemToken[] Children { get; set; }

        public string Key { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
        public MenuItemState MenuItemState { get; set; }
		public IDictionary<string, object> Data { get; set; } 

        public string IconUrl { get; set; }

		public void Set(string key, object value)
		{
			Data.Add(key, value);
		}

		public void Value<T>(string key, Action<T> continuation)
		{
			if (!Has(key)) return;

			continuation(Get<T>(key));
		}

		public T Get<T>(string key)
		{
			return Data.Get<T>(key);
		}

		public bool Has(string key)
		{
			return Data.ContainsKey(key);
		}

        public bool Equals(MenuItemToken other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Key, Key) && Equals(other.Text, Text) && Equals(other.Url, Url) && Equals(other.MenuItemState, MenuItemState);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (MenuItemToken)) return false;
            return Equals((MenuItemToken) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Key != null ? Key.GetHashCode() : 0);
                result = (result*397) ^ (Text != null ? Text.GetHashCode() : 0);
                result = (result*397) ^ (Url != null ? Url.GetHashCode() : 0);
                result = (result*397) ^ (MenuItemState != null ? MenuItemState.GetHashCode() : 0);
                return result;
            }
        }

        public override string ToString()
        {
            return string.Format("Key: {0}, Text: {1}, Url: {2}, MenuItemState: {3} Description: {4}", Key, Text, Url, MenuItemState, Description);
        }
    }
}