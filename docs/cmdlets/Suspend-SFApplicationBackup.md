# Suspend-SFApplicationBackup
Suspends periodic backup for the specified Service Fabric application.
## Description

The application which is configured to take periodic backups, is suspended for taking further backups till it is 
resumed again. This operation applies to the entire application's hierarchy. It means all the services and partitions 
under this application are now suspended for backup.



