-- Enable SQLCMD mode in SSMS before running this script
-- Query → SQLCMD Mode
-- Replace the . in the file paths below to the correct location of the Scripts folder in your system.
-- Run the script.

-- Runs the listed scripts one by one
PRINT 'Executing 1_InsertData.sql ...';
:r ".\1_InsertData.sql"
PRINT 'Executed 1_InsertData.sql successfully.';

PRINT 'Executing 2_InsertFormEligibilityData.sql ...';
:r ".\2_InsertFormEligibilityData.sql"
PRINT 'Executed 2_InsertFormEligibilityData.sql successfully.';

PRINT 'Executing 3_InsertIncludedCoverageEnhancementsData.sql ...';
:r ".\3_InsertIncludedCoverageEnhancementsData.sql"
PRINT 'Executed 3_InsertIncludedCoverageEnhancementsData.sql successfully.';

PRINT 'Executing 4_InsertOptCovTable1Data.sql ...';
:r ".\4_InsertOptCovTable1Data.sql"
PRINT 'Executed 4_InsertOptCovTable1Data.sql successfully.';

PRINT 'Executing 5_InsertOptionalCoverageTable1Data.sql ...';
:r ".\5_InsertOptionalCoverageTable1Data.sql"
PRINT 'Executed 5_InsertOptionalCoverageTable1Data.sql successfully.';

PRINT 'Executing 6_InsertIndustryModifiersData.sql ...';
:r ".\6_InsertIndustryModifiersData.sql"
PRINT 'Executed 6_InsertIndustryModifiersData.sql successfully.';

PRINT 'Executing 7_InsertOptionalAdditionalCoverageFactorsData.sql ...';
:r ".\7_InsertOptionalAdditionalCoverageFactorsData.sql"
PRINT 'Executed 7_InsertOptionalAdditionalCoverageFactorsData.sql successfully.';

PRINT 'Executing 8_InsertDisplayedDefaultPerilsData.sql ...';
:r ".\8_InsertDisplayedDefaultPerilsData.sql"
PRINT 'Executed 8_InsertDisplayedDefaultPerilsData.sql successfully.';

PRINT 'Executing 9_InsertDataValidationsData.sql ...';
:r ".\9_InsertDataValidationsData.sql"
PRINT 'Executed 9_InsertDataValidationsData.sql successfully.';


PRINT 'Executing 10_InsertOptionalCoveragesTable2sData.sql ...';
:r ".\10_InsertOptionalCoveragesTable2sData.sql"
PRINT 'Executed 10_InsertOptionalCoveragesTable2sData.sql successfully.';

PRINT 'All scripts executed successfully.';