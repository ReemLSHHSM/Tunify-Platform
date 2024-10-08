﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylist _context;

        public PlaylistsController(IPlaylist context)
        {
            _context = context;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> Getplaylists()
        {
          
            return await _context.getAllPlaylist();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
          
            return Ok(_context.getPlaylist(id));
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
           var data= _context.UpdatePlaylist(playlist, id);

            return Ok(data);
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure playlistSongs is not required if it is not part of the request payload
            if (playlist.PlaylistSongs == null)
            {
                playlist.PlaylistSongs = new List<PlaylistSongs>();
            }

            return Ok(await _context.AddPlaylist(playlist));
        }


        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            _context.DeleteUser(id);

            return NoContent();
        }

        [HttpPost("playlists/{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddToPlaylist(int playlistId, int songId)
        {
            var playlistsong = await _context.addToPlaylist(playlistId, songId);
            if (playlistsong == null)
            {
                return BadRequest("Failed to add song to playlist.");
            }
            return Ok(playlistsong);
        }


    }
}
