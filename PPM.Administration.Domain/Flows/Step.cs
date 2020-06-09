﻿using PPM.Domain.ValueObject;
using System;

namespace PPM.Administration.Domain.Flows
{
    public class Step
    {
        public Guid Id { get; private set; }
        public Location Location { get; private set; }
        public Percentage Percentage { get; private set; }
        public string StepName { get; private set; }
        public int MaxDaysRequiredToFinish { get; private set; }
        public int StepNumber { get; private set; }


        public Step(Guid id, Location location, int percentage, int days,
            string stepName, int stepNumber)
        {
            Id = id;
            Location = location;
            Percentage = Percentage.Of(percentage);
            MaxDaysRequiredToFinish = days;
            StepName = stepName;
            StepNumber = stepNumber;
        }
        public void SetSetNumber(int number)
        {
            StepNumber = number;
        }     
    }
}