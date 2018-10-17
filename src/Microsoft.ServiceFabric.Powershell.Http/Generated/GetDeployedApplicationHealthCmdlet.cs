// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Gets the information about health of an application deployed on a Service Fabric node.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFDeployedApplicationHealth")]
    public partial class GetDeployedApplicationHealthCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NodeName. The name of the node.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0)]
        public NodeName NodeName { get; set; }

        /// <summary>
        /// Gets or sets ApplicationId. The identity of the application. This is typically the full name of the application
        /// without the 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the application name is "fabric:/myapp/app1", the application identity would be "myapp~app1" in
        /// 6.0+ and "myapp/app1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets EventsHealthStateFilter. Allows filtering the collection of HealthEvent objects returned based on
        /// health state.
        /// The possible values for this parameter include integer value of one of the following health states.
        /// Only events that match the filter are returned. All events are used to evaluate the aggregated health state.
        /// If not specified, all entries are returned. The state values are flag-based enumeration, so the value could be a
        /// combination of these values, obtained using the bitwise 'OR' operator. For example, If the provided value is 6 then
        /// all of the events with HealthState value of OK (2) and Warning (4) are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2)]
        public int? EventsHealthStateFilter { get; set; }

        /// <summary>
        /// Gets or sets DeployedServicePackagesHealthStateFilter. Allows filtering of the deployed service package health
        /// state objects returned in the result of deployed application health query based on their health state.
        /// The possible values for this parameter include integer value of one of the following health states.
        /// Only deployed service packages that match the filter are returned. All deployed service packages are used to
        /// evaluate the aggregated health state of the deployed application.
        /// If not specified, all entries are returned.
        /// The state values are flag-based enumeration, so the value can be a combination of these values, obtained using the
        /// bitwise 'OR' operator.
        /// For example, if the provided value is 6 then health state of service packages with HealthState value of OK (2) and
        /// Warning (4) are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3)]
        public int? DeployedServicePackagesHealthStateFilter { get; set; }

        /// <summary>
        /// Gets or sets ExcludeHealthStatistics. Indicates whether the health statistics should be returned as part of the
        /// query result. False by default.
        /// The statistics show the number of children entities in health state Ok, Warning, and Error.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4)]
        public bool? ExcludeHealthStatistics { get; set; }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5)]
        public long? ServerTimeout { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var result = this.ServiceFabricClient.Applications.GetDeployedApplicationHealthAsync(
                nodeName: this.NodeName,
                applicationId: this.ApplicationId,
                eventsHealthStateFilter: this.EventsHealthStateFilter,
                deployedServicePackagesHealthStateFilter: this.DeployedServicePackagesHealthStateFilter,
                excludeHealthStatistics: this.ExcludeHealthStatistics,
                serverTimeout: this.ServerTimeout,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            this.WriteObject(this.FormatOutput(result));
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
