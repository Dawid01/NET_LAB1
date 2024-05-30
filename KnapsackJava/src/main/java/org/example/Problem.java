package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Problem {
    public List<Item> itemList = new ArrayList<>();
    public List<Item> sortedItemList;

    public Problem(int n, int seed, int lowerBound, int upperBound) {

        if (lowerBound > upperBound) {
            throw new IllegalArgumentException("Upper bound must be equal or greater than lower bound.");
        }

        Random rand = new Random(seed);
        for (int i = 0; i < n; i++) {
            Item item = new Item(i, rand.nextInt(upperBound - lowerBound + 1) + lowerBound, rand.nextInt(upperBound - lowerBound + 1) + lowerBound);
            itemList.add(item);
        }
    }

    public Result solve(int capacity) {
        sortedItemList = new ArrayList<>(itemList);
        sortedItemList.sort((Item o1, Item o2) -> Double.compare(o2.getRatio(), o1.getRatio()));

        List<Integer> selectedItems = new ArrayList<>();
        int totalValue = 0;
        int totalWeight = 0;

        for (Item item : sortedItemList) {
            while (totalWeight + item.getWeight() <= capacity) {
                totalWeight += item.getWeight();
                totalValue += item.getValue();
                selectedItems.add(item.getId());
            }
        }
        return new Result(totalValue, totalWeight, selectedItems);
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        for (Item item : itemList) {
            result.append("Id: ").append(item.getId())
                    .append(", Value: ").append(item.getValue())
                    .append(", Weight: ").append(item.getWeight())
                    .append(", Ratio: ").append(item.getRatio())
                    .append("\n");
        }
        return result.toString();
    }
}
