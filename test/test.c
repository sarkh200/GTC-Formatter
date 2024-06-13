#include <stdio.h>
#include <math.h>

void printTri(char character, int height);

int main(void)
{
	char inputChar;
	int height;
	printf("Enter a character: ");
	scanf("%c", &inputChar);
	printf("\nLet's draw an isosceles triangle with your character %c.\n", inputChar);

	printf("Enter a value for the height of the triangle: ");
	scanf("%d", &height);
	printf("(Base will be the same as height.)\n\n");

	printTri(inputChar, height);

	printf("\nThe area of your triangle is: %.2f\n", powf(height, 2) / 2);
}

// Comment,;() that is very cool
/*comment adsasdasa*/
void printTri(char character, int height)
{
	for (int i = 0; i < height; i++)
	{
		for (int j = 0; j < height - i; j++)
		{
			printf(" ");
		}
		for (int j = 0; j <= i; j++)
		{
			printf("%c ", character);
		}
		printf("\n");
	}
	int i = 0;
	while (i < height)
	{
		for (int j = 0; j < height - i; j++)
		{
			printf(" ");
		}
		for (int j = 0; j <= i; j++)
		{
			printf("%c ", character);
		}
		printf("\n");
		i++;
	}
}