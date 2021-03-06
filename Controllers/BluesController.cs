﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayingTheBlues.Models;

namespace PlayingTheBlues.Controllers
{
    [Route("api/blues")]
    public class BluesController : Controller
    {
        [HttpGet]
        public IActionResult GetChords([FromQuery] string tonic)

        {
            var chords = new BluesChords();
            chords.Tonic = tonic;
            

            List<string> tones = new List<string>();//the list from the tones you can choose
            tones.Add("Cb");
            tones.Add("Gb");
            tones.Add("Db");
            tones.Add("Ab");
            tones.Add("Eb");
            tones.Add("Bb");
            tones.Add("F");
            tones.Add("C");
            tones.Add("G");
            tones.Add("D");
            tones.Add("A");
            tones.Add("E");
            tones.Add("B");
            tones.Add("F#");
            tones.Add("C#");
            if (tones.Contains(chords.Tonic))//check if the user input belongs to the list of tones

            {
                if (chords.Tonic == "Cb") // enharmonically change the first tone of the list
                    chords.Tonic = "B";
                else if (chords.Tonic == "C#")// enharmonically change the last tone of the list
                    chords.Tonic = "Db";
                bool check = tones.Contains(chords.Tonic); //check if the tone exists in tones list
                if (check)
                {
                    int rootindex, subdomindex, domindex;//variables for the position of I,IV,V chords
                    rootindex = tones.IndexOf(chords.Tonic);//user input as I chord
                    subdomindex = rootindex - 1;// index of IV chord (thing the cycle of 4ths, counterclockwise)
                    domindex = rootindex + 1;// index of V chord (thing the cycle of 5ths, clockwise)

                    chords.SubDominant = tones[subdomindex];
                    chords.Dominant = tones[domindex];
                }

                return Ok(chords);
            }
            else
                return NotFound();





        }

    }
}

