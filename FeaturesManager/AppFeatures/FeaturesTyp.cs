//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Lifeprojects.de">
//     Class: Program
//     Copyright © Lifeprojects.de 2023
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>17.02.2023 07:52:55</date>
//
// <summary>
// Konsolen Applikation mit Menü
// </summary>
//-----------------------------------------------------------------------

namespace FMDemo.Features
{
    using System;

    public enum FeaturesTyp
    {
        [Feature("C8363A8B-4456-4A58-BAA8-CCDB19B4EF0C","Feature A")]
        Features1 = 1,
        [Feature("0470FBCD-C6A7-4E2D-BFD9-5E220B89AD0B", "Feature B")]
        Features2 = 2,
    }
}
