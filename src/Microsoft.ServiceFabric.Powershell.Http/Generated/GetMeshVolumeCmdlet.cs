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
    /// Lists all the volume resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshVolume", DefaultParameterSetName = "List")]
    public partial class GetMeshVolumeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets VolumeResourceName. The identity of the volume.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Get")]
        public string VolumeResourceName { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            if (this.ParameterSetName.Equals("List"))
            {
                var continuationToken = ContinuationToken.Empty;
                do
                {
                    var result = this.ServiceFabricClient.MeshVolumes.ListAsync().GetAwaiter().GetResult();

                    var count = 0;
                    foreach (var item in result.Data)
                    {
                        count++;
                        this.WriteObject(this.FormatOutput(item));
                    }

                    continuationToken = result.ContinuationToken;
                    this.WriteDebug(string.Format(Resource.MsgCountAndContinuationToken, count, continuationToken));
                }
                while (continuationToken.Next);
            }
            else if (this.ParameterSetName.Equals("Get"))
            {
                var result = this.ServiceFabricClient.MeshVolumes.GetAsync(
                    volumeResourceName: this.VolumeResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
