FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java SumVideoDurations < "%%f" > "!file:.in.txt=.out.txt!"
)
