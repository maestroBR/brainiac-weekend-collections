# Compatibility

Targets SPT 4.1.6, WeekendDrops 1.0.7 and Brainiac Collectibles >=1.2.0 <2.0.0.

| Check | Status |
| --- | --- |
| Build against WeekendDrops 1.0.7 | Passed |
| Collection data | Validated |
| Existing collection preservation and duplicate prevention | Passed in isolation |
| Standalone package startup | Pending |
| Donations, rewards and Fika gameplay | Pending |

The integration uses CollectionService.LoadConfig and Weekend's _config field. Changes to that API require renewed validation. SPT, Weekend and Harmony DLLs are not included.
