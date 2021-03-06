package ExamPreparation01.cresla.entities;

import ExamPreparation01.cresla.interfaces.Identifiable;

public abstract class AbstractIdentifiable implements Identifiable {

    private static int nextId = 1;

    private int id;

    protected AbstractIdentifiable() {
        this.id = nextId;
        nextId++;
    }

    @Override
    public int getId() {
        return this.id;
    }
}
