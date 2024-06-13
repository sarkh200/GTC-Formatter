#include <stdio.h>

int main()
{
	int i, j;
	for (i = 0; i < 5; i++)
	{
		printf("Outer loop iteration: %d\n", i);
		for (j = 0; j < 3; j++)
		{
			printf("  Inner loop iteration: %d\n", j);
			for (int k = 0; k < 2; k++)
			{
				printf("    Nested loop iteration: %d\n", k);
				if (k == 1)
				{
					printf("      Special message!\n");
				}
			}
		}
		printf("End of inner loop for outer iteration %d\n", i);
	}
	printf("Program complete!\n");

	return 0;
}