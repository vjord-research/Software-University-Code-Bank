package ExamPanzerBattles.panzer.models.parts;

import ExamPanzerBattles.panzer.contracts.HitPointsModifyingPart;

import java.math.BigDecimal;

public class EndurancePart extends BasePart implements HitPointsModifyingPart {

    private final int hitPointsModifier;

    public EndurancePart(String model, double weight, BigDecimal price, int hitPointsModifier) {
        super(model, weight, price);
        this.hitPointsModifier = hitPointsModifier;
    }

    @Override
    public int getHitPointsModifier() {
        return this.hitPointsModifier;
    }
}
