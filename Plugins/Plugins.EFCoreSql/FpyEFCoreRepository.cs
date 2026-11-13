using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using FPY.CoreBussines;
using FPYDashboard.Plugins.EFCoreSqlServer;
using Microsoft.EntityFrameworkCore;

namespace Plugins.EFCoreSql
{
    public class FpyEFCoreRepository : IFpyEFCoreRepository
    {
        private readonly FpyDbContext _context;
        public FpyEFCoreRepository(FpyDbContext context)
        {
            _context = context;
        }

        public async Task<List<MonthlyFpy>> GetHydrBVResultsMonthlyFpyAsync()
        {
            var sql = """
                SET LANGUAGE Polish;
                WITH NumberedTest AS (
                	SELECT
                		Serial_Nr,
                		MONTH(Date) AS Month,
                		[Date],
                		[Time],
                		General_Result,
                		ROW_NUMBER() OVER
                			(
                				PARTITION BY Serial_Nr
                				ORDER BY [Date], [Time]
                			) AS Test_Order
                	FROM dbo.HydrBVResults1
                	),
                	FirstTest AS (
                		SELECT 
                			Month,
                			YEAR(Date) AS [Year],
                			[Time],
                			General_Result
                		FROM NumberedTest
                		WHERE Test_Order = 1

                	)
                    SELECT
                        [Year],
                        DATENAME(MONTH, DATEFROMPARTS(2026, [Month], 1)) AS MonthName,
                		SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS [OK],
                		NULLIF(COUNT(*), 0) - SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS [NOK],
                		NULLIF(COUNT(*), 0) AS [ALL],
                        CAST(
                            100.0 * SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END)
                            / NULLIF(COUNT(*), 0)
                            AS decimal(5, 2)
                        ) AS FPY
                    FROM FirstTest
                    GROUP BY [Year], [Month]
                    ORDER BY [Year] DESC, [Month] DESC;
                			
                """;

                return await _context.Database
                    .SqlQueryRaw<MonthlyFpy>(sql)
                    .ToListAsync();
        }

        public async Task<List<WeeklyFpy>> GetHydrBVResultsWeeklyFpyAsync()
        {
            var sql = """
                SET LANGUAGE Polish;

                WITH NumberedTest AS (
                	SELECT
                		Serial_Nr,
                		Week_of_the_Year,
                		[Date],
                		[Time],
                		General_Result,
                		ROW_NUMBER() OVER
                			( 
                				PARTITION BY Serial_Nr
                				ORDER BY [Date], [Time]
                			) AS Test_Order
                	FROM dbo.HydrBVResults1
                	),

                	First_Test AS (
                		SELECT
                			Week_of_the_Year,
                			Year([Date]) AS [Year],
                			General_Result
                		FROM NumberedTest
                		WHERE Test_Order = 1
                	)
                	SELECT
                		Week_of_the_Year AS Week,
                		[Year],
                		SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS OK,
                		NULLIF(COUNT(*), 0) - SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS NOK,
                		NULLIF(COUNT(*), 0) AS [ALL],
                        CAST(
                            100.0 * SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END)
                            / NULLIF(COUNT(*), 0)
                            AS decimal(5, 2)
                		) AS FPY
                	FROM First_Test
                	GROUP BY [Year], Week_of_the_Year
                	ORDER BY [Year] DESC, Week_of_the_Year DESC;



                
                """;

            return await _context.Database
                .SqlQueryRaw<WeeklyFpy>(sql)
                .ToListAsync();
        }

        public Task<List<MonthlyFpy>> GetHydrResultsMonthlyFpyAsync()
        {
            var sql = """
                SET LANGUAGE Polish;
                WITH NumberedTest AS (
                	SELECT
                		Serial_Nr,
                		MONTH(Date) AS Month,
                		[Date],
                		[Time],
                		General_Result,
                		ROW_NUMBER() OVER
                			(
                				PARTITION BY Serial_Nr
                				ORDER BY [Date], [Time]
                			) AS Test_Order
                	FROM dbo.HydrResults1
                	),
                	FirstTest AS (
                		SELECT 
                			Month,
                			YEAR(Date) AS [Year],
                			[Time],
                			General_Result
                		FROM NumberedTest
                		WHERE Test_Order = 1

                	)
                    SELECT
                        [Year],
                        DATENAME(MONTH, DATEFROMPARTS(2026, [Month], 1)) AS MonthName,
                		SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS [OK],
                		NULLIF(COUNT(*), 0) - SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS [NOK],
                		NULLIF(COUNT(*), 0) AS [ALL],
                        CAST(
                            100.0 * SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END)
                            / NULLIF(COUNT(*), 0)
                            AS decimal(5, 2)
                        ) AS FPY
                    FROM FirstTest
                    GROUP BY [Year], [Month]
                    ORDER BY [Year] DESC, [Month] DESC;
                			
                """;

            return _context.Database
                .SqlQueryRaw<MonthlyFpy>(sql)
                .ToListAsync();
        }

        public Task<List<WeeklyFpy>> GetHydrResultsWeeklyFpyAsync()
        {
            var sql = """
                SET LANGUAGE Polish;

                WITH NumberedTest AS (
                	SELECT
                		Serial_Nr,
                		Week_of_the_Year,
                		[Date],
                		[Time],
                		General_Result,
                		ROW_NUMBER() OVER
                			( 
                				PARTITION BY Serial_Nr
                				ORDER BY [Date], [Time]
                			) AS Test_Order
                	FROM dbo.HydrResults1
                	),

                	First_Test AS (
                		SELECT
                			Week_of_the_Year,
                			Year([Date]) AS [Year],
                			General_Result
                		FROM NumberedTest
                		WHERE Test_Order = 1
                	)
                	SELECT
                		Week_of_the_Year AS Week,
                		[Year],
                		SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS OK,
                		NULLIF(COUNT(*), 0) - SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END) AS NOK,
                		NULLIF(COUNT(*), 0) AS [ALL],
                        CAST(
                            100.0 * SUM(CASE WHEN General_Result = 1 THEN 1.0 ELSE 0.0 END)
                            / NULLIF(COUNT(*), 0)
                            AS decimal(5, 2)
                		) AS FPY
                	FROM First_Test
                	GROUP BY [Year], Week_of_the_Year
                	ORDER BY [Year] DESC, Week_of_the_Year DESC;



                
                """;

            return  _context.Database
                .SqlQueryRaw<WeeklyFpy>(sql)
                .ToListAsync();
        }

        public Task<List<MonthlyFpy>> GetPneuResultsMonthlyFpyAsync()
        {
            var sql = """
                SET LANGUAGE Polish;
                WITH NumberedTest AS (
                	SELECT
                		Serial_Nr,
                		MONTH(Date) AS Month,
                		[Date],
                		[Time],
                		General,
                		ROW_NUMBER() OVER
                			(
                				PARTITION BY Serial_Nr
                				ORDER BY [Date], [Time] 
                			) AS Test_Order
                	FROM dbo.PneuResults1
                	),
                	FirstTest AS (
                		SELECT 
                			Month,
                			YEAR(Date) AS [Year],
                			[Time],
                			General
                		FROM NumberedTest
                		WHERE Test_Order = 1

                	)
                    SELECT
                        [Year],
                        DATENAME(MONTH, DATEFROMPARTS(2026, [Month], 1)) AS MonthName,
                		SUM(CASE WHEN General = 1 THEN 1.0 ELSE 0.0 END) AS [OK],
                		NULLIF(COUNT(*), 0) - SUM(CASE WHEN General = 1 THEN 1.0 ELSE 0.0 END) AS [NOK],
                		NULLIF(COUNT(*), 0) AS [ALL],
                        CAST(
                            100.0 * SUM(CASE WHEN General = 1 THEN 1.0 ELSE 0.0 END)
                            / NULLIF(COUNT(*), 0)
                            AS decimal(5, 2)
                        ) AS FPY
                    FROM FirstTest
                    GROUP BY [Year], [Month]
                    ORDER BY [Year] DESC, [Month] DESC;
                			
                """;

            return  _context.Database
                .SqlQueryRaw<MonthlyFpy>(sql)
                .ToListAsync();
        }

        public Task<List<WeeklyFpy>> GetPneuResultsWeeklyFpyAsync()
        {
            var sql = """
                SET LANGUAGE Polish;

                WITH NumberedTest AS (
                	SELECT
                		Serial_Nr,
                		Week_of_the_Year,
                		[Date],
                		[Time],
                		General,
                		ROW_NUMBER() OVER
                			( 
                				PARTITION BY Serial_Nr
                				ORDER BY [Date], [Time]
                			) AS Test_Order
                	FROM dbo.PneuResults1
                	),

                	First_Test AS (
                		SELECT
                			Week_of_the_Year,
                			Year([Date]) AS [Year],
                			General
                		FROM NumberedTest
                		WHERE Test_Order = 1
                	)
                	SELECT
                		Week_of_the_Year AS Week,
                		[Year],
                		SUM(CASE WHEN General = 1 THEN 1.0 ELSE 0.0 END) AS OK,
                		NULLIF(COUNT(*), 0) - SUM(CASE WHEN General = 1 THEN 1.0 ELSE 0.0 END) AS NOK,
                		NULLIF(COUNT(*), 0) AS [ALL],
                        CAST(
                            100.0 * SUM(CASE WHEN General = 1 THEN 1.0 ELSE 0.0 END)
                            / NULLIF(COUNT(*), 0)
                            AS decimal(5, 2)
                		) AS FPY
                	FROM First_Test
                	GROUP BY [Year], Week_of_the_Year
                	ORDER BY [Year] DESC, Week_of_the_Year DESC;                
                """;

            return _context.Database
                .SqlQueryRaw<WeeklyFpy>(sql)
                .ToListAsync();
        }
    }
}
