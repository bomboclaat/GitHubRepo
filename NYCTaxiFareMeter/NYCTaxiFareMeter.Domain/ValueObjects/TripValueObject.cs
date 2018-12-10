using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace NYCTaxiFareMeter.Domain.ValueObjects
{
    /// <summary>
    /// Value object containing trip data.
    /// </summary>
    public class TripValueObject
    {
        /// <summary>
        /// Time and date ride started.
        /// </summary>
        [Required]
        public DateTime StartDateTime { get; private set; }

        /// <summary>
        /// Trip mileage while driving under 6 mph in units of 1/5 of a mile. 
        /// </summary>
        [Required]
        [Range(0, Double.MaxValue)]
        public int Miles { get; private set; }

        /// <summary>
        /// Trip time while not in motion or traveling at 6 miles per hour or more.
        /// </summary>
        [Required]
        [Range(0, Double.MaxValue)]
        public int Minutes { get; private set; }

        /// <summary>
        /// Factory method for creating <see cref="TripValueObject"/>.
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="miles"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static TripValueObject Create(DateTime startDateTime, int miles, int minutes)
        {
            TripValueObject tripValueObject = new TripValueObject();
            tripValueObject.StartDateTime = startDateTime;
            tripValueObject.Miles = miles;
            tripValueObject.Minutes = minutes;

            tripValueObject.Validate();

            return tripValueObject;
        }

        /// <summary>
        /// Validate object.
        /// </summary>
        private void Validate()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                throw new ValidationException(sbrErrors.ToString());
            }
        }
    }
}