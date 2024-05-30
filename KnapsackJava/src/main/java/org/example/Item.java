package org.example;

public class Item {

    private final int id;
    private final int weight;
    private final int value;
    private final double ratio;

    public Item(int id, int weight, int value) {
        this.id = id;
        this.weight = weight;
        this.value = value;
        this.ratio = (double) value / (double) weight;;
    }

    public int getId() {
        return id;
    }

    public int getWeight() {
        return weight;
    }

    public int getValue() {
        return value;
    }

    public double getRatio() {
        return ratio;
    }
}
