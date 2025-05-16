/*
 * <copyright file="ApplicationFeatures.cs" company="Lifeprojects.de">
 *     Class: ApplicationFeatures
 *     Copyright © Lifeprojects.de 2023
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>17.02.2023 17:50:44</date>
 * <Project>CurrentProject</Project>
 *
 * <summary>
 * Beschreibung zur Klasse
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

namespace FMDemo.Features
{
    using System;

    using ModernBaseLibrary.Extension;

    public class ApplicationFeatures : FeaturesManagerBase
    {
        private static LocalFeatures localFeatures = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationFeatures"/> class.
        /// </summary>
        public ApplicationFeatures()
        {
            localFeatures = new LocalFeatures();
            if (localFeatures != null)
            {
                this.InitFeatures();
            }
        }

        static ApplicationFeatures()
        {
            if (localFeatures != null)
            {
                localFeatures.Load();
            }
            else
            {
                localFeatures = new LocalFeatures();
                localFeatures.Load();
            }
        }


        public static bool HasFeatures(Guid key)
        {
            if (localFeatures != null)
            {
                return localFeatures.Exists(key);
            }
            else
            {
                return false;
            }
        }

        public static bool HasFeatures(string key)
        {
            if (localFeatures != null)
            {
                return localFeatures.Exists(new Guid(key));
            }
            else
            {
                return false;
            }
        }

        public static bool HasFeatures(FeaturesTyp key)
        {
            FeatureAttribute guidKey = key.GetAttributeOfType<FeatureAttribute>();

            if (localFeatures != null)
            {
                return localFeatures.Exists(guidKey.Guid);
            }
            else
            {
                return false;
            }
        }

        public static FeaturesResult Get(Guid key)
        {
            if (localFeatures != null)
            {
                return localFeatures.Get(key);
            }
            else
            {
                return default;
            }
        }

        public static FeaturesResult Get(string key)
        {
            if (localFeatures != null)
            {
                return localFeatures.Get(new Guid(key));
            }
            else
            {
                return default;
            }
        }

        public static FeaturesResult Get(FeaturesTyp key)
        {
            FeatureAttribute guidKey = key.GetAttributeOfType<FeatureAttribute>();

            if (localFeatures != null)
            {
                return localFeatures.Get(guidKey.Guid);
            }
            else
            {
                return default;
            }
        }

        public override void InitFeatures()
        {
            if (localFeatures.IsExitFeatures() == false)
            {
                FeaturesTyp f1 = FeaturesTyp.Features1;
                FeatureAttribute guidKey = f1.GetAttributeOfType<FeatureAttribute>();
                guidKey.Guid = Guid.Empty;
                localFeatures.AddOrSet(guidKey.Guid, guidKey.Description);

                FeaturesTyp f2 = FeaturesTyp.Features2;
                guidKey = f2.GetAttributeOfType<FeatureAttribute>();
                guidKey.Guid = Guid.Empty;
                localFeatures.AddOrSet(guidKey.Guid, guidKey.Description);

                localFeatures.Save();
                localFeatures.Load();
            }
            else
            {
                localFeatures.Load();
            }
        }
    }
}
