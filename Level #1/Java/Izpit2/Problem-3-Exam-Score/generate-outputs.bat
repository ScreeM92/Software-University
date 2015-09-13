FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java ExamScoreAggregator < "%%f" > "!file:.in.txt=.out.txt!"
)
