﻿/*  
  Aras.Model provides a .NET cient library for Aras Innovator

  Copyright (C) 2015 Processwall Limited.

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU Affero General Public License as published
  by the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU Affero General Public License for more details.

  You should have received a copy of the GNU Affero General Public License
  along with this program.  If not, see http://opensource.org/licenses/AGPL-3.0.
 
  Company: Processwall Limited
  Address: The Winnowing House, Mill Lane, Askham Richard, York, YO23 3NW, United Kingdom
  Tel:     +44 113 815 3440
  Email:   support@processwall.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aras.ViewModel.Properties
{
    [Attributes.ClientControl("Aras.View.Properties.ListValue")]
    public class ListValue : Control
    {
        private System.String _value;
        [Attributes.Property("Value", Attributes.PropertyTypes.String, true)]
        public System.String Value 
        { 
            get
            {
                return this._value;
            }
            set 
            { 
                if (System.String.Compare(this._value, value) != 0)
                {
                    this._value = value;
                    this.OnPropertyChanged("Value");
                }
            }
        }

        private System.String _label;
        [Attributes.Property("Label", Attributes.PropertyTypes.String, true)]
        public System.String Label
        {
            get
            {
                return this._label;
            }
            set
            {
                if (System.String.Compare(this._label, value) != 0)
                {
                    this._label = value;
                    this.OnPropertyChanged("Label");
                }
            }
        }

        protected override void CheckBinding(object Binding)
        {
            base.CheckBinding(Binding);

            if (Binding != null)
            {
                if (!(Binding is Model.Relationships.Value))
                {
                    throw new Model.Exceptions.ArgumentException("Binding must be of type Aras.Model.ListValue");
                }
            }
        }

        protected override void AfterBindingChanged()
        {
            base.AfterBindingChanged();

            if (this.Binding != null)
            {
                this.Value = (System.String)((Model.Relationships.Value)this.Binding).Property("value").Value;
                this.Label = (System.String)((Model.Relationships.Value)this.Binding).Property("label").Value;
            }
            else
            {
                this.Value = null;
                this.Label = null;
            }
        }

        protected override void BeforeBindingChanged()
        {
            base.BeforeBindingChanged();

            if (this.Binding != null)
            {
                this.Value = null;
                this.Label = null;
            }
        }

        public override string ToString()
        {
            return this.Value;
        }

        public ListValue(Manager.Session Session)
            :base(Session)
        {

        }
    }
}
