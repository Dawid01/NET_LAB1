package org.example;


import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = getInput(sc, "Enter the number of items:");
        int seed = getInput(sc, "Enter the seed:");
        int lowerBound = getInput(sc, "Enter the lower bound:");
        int upperBound = getInput(sc, "Enter the upper bound:");

        while (lowerBound > upperBound) {
            System.out.println("Lower bound cannot be greater than upper bound. Please enter the bounds again.");
            lowerBound = getInput(sc, "Enter the lower bound:");
            upperBound = getInput(sc, "Enter the upper bound:");
        }

        Problem problem = new Problem(n, seed, lowerBound, upperBound);

        int capacity = getInput(sc, "Enter the capacity of the knapsack:");

        System.out.println("\nGenerated Items:");
        System.out.println(problem);

        Result result = problem.solve(capacity);

        System.out.println("\nKnapsack Result:");
        System.out.println(result);
    }

    private static int getInput(Scanner sc, String prompt) {
        System.out.println(prompt);
        while (!sc.hasNextInt()) {
            System.out.println("Invalid input. Please enter an integer.");
            sc.next();
        }
        return sc.nextInt();
    }
}