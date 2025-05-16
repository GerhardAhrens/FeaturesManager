/*
 * <copyright file="FeatureAttribute.cs" company="Lifeprojects.de">
 *     Class: FeatureAttribute
 *     Copyright © Lifeprojects.de 2025
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>16.05.2025</date>
 * <Project>FeaturesManager</Project>
 *
 * <summary>
 * Attribute für Enum um eine Guid mit Enum-Item verbinden zu können
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

namespace System
{
    public class FeatureAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
        /// </summary>
        public FeatureAttribute(string guid)
        {
            this.Guid = new Guid(guid);
        }

        public FeatureAttribute(string guid, string description)
        {
            this.Guid = new Guid(guid);
            this.Description = description;
        }

        public Guid Guid { get; set; } = Guid.Empty;
        public string Description { get; set; }
    }
}
