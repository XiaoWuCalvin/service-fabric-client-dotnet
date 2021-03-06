# Start-SFQuorumLoss
Induces quorum loss for a given stateful service partition.
## Description

This API is useful for a temporary quorum loss situation on your service.
                
                Call the GetQuorumLossProgress API with the same OperationId to return information on the operation 
started with this API.
                
                This can only be called on stateful persisted (HasPersistedState==true) services.  Do not use this API 
on stateless services or stateful in-memory only services.



## Required Parameters
#### -ServiceId

The identity of the service. This ID is typically the full name of the service without the 'fabric:' URI scheme.
                    Starting from version 6.0, hierarchical names are delimited with the "~" character.
                    For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be 
"myapp~app1~svc1" in 6.0+ and "myapp/app1/svc1" in previous versions.



#### -PartitionId

The identity of the partition.



#### -OperationId

A GUID that identifies a call of this API.  This is passed into the corresponding GetProgress API



#### -QuorumLossMode

This enum is passed to the StartQuorumLoss API to indicate what type of quorum loss to induce. Possible values 
include: 'Invalid', 'QuorumReplicas', 'AllReplicas'



#### -QuorumLossDuration

The amount of time for which the partition will be kept in quorum loss.  This must be specified in seconds.



