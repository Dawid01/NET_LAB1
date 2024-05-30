package org.example;

import org.junit.jupiter.api.Test;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class ProblemTest {

    @Test
    void testNonEmptySelectedItems() {
        Problem problem = new Problem(3, 1, 1, 10);
        Result result = problem.solve(10);

        assertFalse(result.selectedItems.isEmpty(), "The selected items should not be empty when capacity allows for items to be added.");
    }

    @Test
    void testNoSelectedItemsWithLowCapacity() {
        Problem problem = new Problem(3, 1, 1, 10);
        Result result = problem.solve(1);

        assertEquals(0, result.selectedItems.size(), "The selected items should be empty when capacity is too low to include any items.");
    }

    @Test
    void testItemValueAndWeightWithinBounds() {
        int n = 3;
        int seed = 1;
        int lowerBound = 1;
        int upperBound = 10;
        Problem problem = new Problem(n, seed, lowerBound, upperBound);
        List<Item> items = problem.itemList;

        for (Item item : items) {
            assertTrue(item.getValue() >= lowerBound && item.getValue() <= upperBound,
                    "Item value should be within the specified bounds.");
            assertTrue(item.getWeight() >= lowerBound && item.getWeight() <= upperBound,
                    "Item weight should be within the specified bounds.");
        }
    }


    @Test
    void testExpectedSelectedItems() {
        Problem problem = new Problem(5, 5, 5, 15);
        int capacity = 30;
        Result result = problem.solve(capacity);
        int[] actual = result.selectedItems.stream().mapToInt(Integer::intValue).toArray();
        int[] expected = {4, 4, 0};

        assertArrayEquals(expected, actual, "The selected items should match the expected selection based on the given capacity and item list.");
    }
}
