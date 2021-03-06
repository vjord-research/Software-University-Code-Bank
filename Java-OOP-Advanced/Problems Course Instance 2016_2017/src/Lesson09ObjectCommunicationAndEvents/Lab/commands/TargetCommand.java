package Lesson09ObjectCommunicationAndEvents.Lab.commands;

import Lesson09ObjectCommunicationAndEvents.Lab.interfaces.Attacker;
import Lesson09ObjectCommunicationAndEvents.Lab.interfaces.Command;
import Lesson09ObjectCommunicationAndEvents.Lab.interfaces.ObservableTarget;

public class TargetCommand implements Command {

    private Attacker attacker;
    private ObservableTarget target;

    public TargetCommand(Attacker attacker, ObservableTarget target) {
        this.attacker = attacker;
        this.target = target;
    }

    @Override
    public void execute() {
        this.attacker.setTarget(target);
    }
}
