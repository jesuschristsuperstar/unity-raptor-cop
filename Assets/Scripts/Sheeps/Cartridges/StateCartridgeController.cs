﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCartridgeController : MonoBehaviour {
	public enum State
	{
		Idle,
		Graze,
		Startled,
		Petrified,
		Dead
	}

	public Cartridge_Idle idleCartridge = new Cartridge_Idle();
	public Cartridge_Graze grazeCartridge = new Cartridge_Graze();
	public Cartridge_Startled startledCartridge = new Cartridge_Startled ();
	public Cartridge_Petrified petrifiedCartridge = new Cartridge_Petrified ();
	public Cartridge_Dead deadCartridge = new Cartridge_Dead();

	public State state = State.Idle;
	public IStateCartridge currentCartridge;

	// Update is called once per frame
	void Update () {
		if(state.Equals(State.Idle)){
			currentCartridge = idleCartridge;
		} else if(state.Equals(State.Graze)){
			currentCartridge = grazeCartridge;
		} else if(state.Equals(State.Startled)){
			currentCartridge = startledCartridge;
		} else if(state.Equals(State.Petrified)){
			currentCartridge = petrifiedCartridge;
		} else if(state.Equals(State.Dead)){
			currentCartridge = deadCartridge;
		} else {
			Debug.LogError("No StateCartridge available for state: "+state.ToString());
			currentCartridge = null;
		}

		if (currentCartridge != null) {
			currentCartridge.Run (gameObject);
		}
	}
}