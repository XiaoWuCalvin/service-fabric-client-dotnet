# Get-SFChaosEvents
Gets the next segment of the Chaos events based on the continuation token or the time range.
## Description

To get the next segment of the Chaos events, you can specify the ContinuationToken. To get the start of a new segment 
of Chaos events, you can specify the time range
                through StartTimeUtc and EndTimeUtc. You cannot specify both the ContinuationToken and the time range 
in the same call.
                When there are more than 100 Chaos events, the Chaos events are returned in multiple segments where a 
segment contains no more than 100 Chaos events and to get the next segment you make a call to this API with the 
continuation token.



## Optional Parameters
#### -StartTimeUtc

The Windows file time representing the start time of the time range for which a Chaos report is to be generated. 
Consult [DateTime.ToFileTimeUtc 
Method](https://msdn.microsoft.com/library/system.datetime.tofiletimeutc(v=vs.110).aspx) for details.



#### -EndTimeUtc

The Windows file time representing the end time of the time range for which a Chaos report is to be generated. Consult 
[DateTime.ToFileTimeUtc Method](https://msdn.microsoft.com/library/system.datetime.tofiletimeutc(v=vs.110).aspx) for 
details.



#### -MaxResults

The maximum number of results to be returned as part of the paged queries. This parameter defines the upper bound on 
the number of results returned. The results returned can be less than the specified maximum results if they do not fit 
in the message as per the max message size restrictions defined in the configuration. If this parameter is zero or not 
specified, the paged query includes as many results as possible that fit in the return message.



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



