/*
 * <copyright file="EnumExtensions.cs" company="Lifeprojects.de">
 *     Class: EnumExtensions
 *     Copyright © Lifeprojects.de 2022
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>25.09.2022 08:40:08</date>
 * <Project>EasyPrototypingNET</Project>
 *
 * <summary>
 * EnumExtensions Definition
 * </summary>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful,but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.You should have received a copy of the GNU General Public License along with this program. 
 * If not, see <http://www.gnu.org/licenses/>.
*/

namespace ModernBaseLibrary.Extension
{
    using System;

    public static partial class EnumExtensions
    {
        public static TEnum GetAttributeOfType<TEnum>(this Enum @this) where TEnum : Attribute
        {
            object[] attributes = null;

            try
            {
                var type = @this.GetType();
                var memInfo = type.GetMember(@this.ToString());
                attributes = memInfo[0].GetCustomAttributes(typeof(TEnum), false);
            }
            catch (Exception)
            {

                throw;
            }

            return (attributes.Length > 0) ? (TEnum)attributes[0] : null;
        }
    }
}