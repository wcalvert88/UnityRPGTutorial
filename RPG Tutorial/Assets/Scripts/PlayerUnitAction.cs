using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField] private GameObject physicalAttack;

	[SerializeField] GameObject magicalAttack;

	List<UnitStats> unitsStats;

	private GameObject currentAttack;

	void Awake() {
		this.physicalAttack = Instantiate(this.physicalAttack, this.transform) as GameObject;
		this.magicalAttack = Instantiate(this.magicalAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;

		this.currentAttack = this.physicalAttack;
	}

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget>().hit(target);
	}

	public void nextTurn() {
		UnitStats currentUnitStats = unitsStats[0];
		unitsStats.Remove(currentUnitStats);

		if(!currentUnitStats.isDead()) {
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.calculateNextActTurn(currentUnitStats.nextActTurn);
			unitsStats.Add(currentUnitStats);
			unitsStats.Sort();

			if (currentUnit.tag == "PlayerUnit") {
				Debug.Log("Player unit acting");
			} else {
				currentUnit.GetComponent<EnemyUnitAction>().act();
			}
		} else {
			this.nextTurn();
		}
	}

	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
	}
}
