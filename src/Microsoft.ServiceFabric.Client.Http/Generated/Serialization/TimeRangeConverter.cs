// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="TimeRange" />.
    /// </summary>
    internal class TimeRangeConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static TimeRange Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static TimeRange GetFromJsonProperties(JsonReader reader)
        {
            var startTime = default(TimeOfDay);
            var endTime = default(TimeOfDay);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("StartTime", propName, StringComparison.Ordinal) == 0)
                {
                    startTime = TimeOfDayConverter.Deserialize(reader);
                }
                else if (string.Compare("EndTime", propName, StringComparison.Ordinal) == 0)
                {
                    endTime = TimeOfDayConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new TimeRange(
                startTime: startTime,
                endTime: endTime);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, TimeRange obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.StartTime != null)
            {
                writer.WriteProperty(obj.StartTime, "StartTime", TimeOfDayConverter.Serialize);
            }

            if (obj.EndTime != null)
            {
                writer.WriteProperty(obj.EndTime, "EndTime", TimeOfDayConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
