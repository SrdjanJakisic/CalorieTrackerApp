using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Enums
{
    public enum ActivityLevel
    {
        Sedentary = 0, // x 1.2 седење, без тренинга
        LightlyActive = 1, // x 1.375 лагана активност 1-3х недељно
        ModeratelyActive = 2, // x 1.55 умерена 3-5x недељно
        VeryActive = 3, // x 1.725 напорна 6-7х недељно
        ExtraActive = 4 // х 1.9 физички посао + тренинг
    }
}
