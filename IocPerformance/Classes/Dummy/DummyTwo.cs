﻿using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyTwo
    {
    }

    [Cauldron.Activator.Component(typeof(IDummyTwo))]
    [Export(typeof(IDummyTwo)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummyTwo))]
    public class DummyTwo : IDummyTwo
    {
    }
}
