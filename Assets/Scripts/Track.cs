﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Track", menuName = "Track")]
public class Track : ScriptableObject
{
	public List<Note> lineA;
	public Note[] lineB;
}