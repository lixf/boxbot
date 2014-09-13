package com.boxbot.android;

import java.util.ArrayList;
import java.util.Arrays;

import android.support.v7.app.ActionBarActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class FriendList extends ActionBarActivity {
	
	private ListView mainListView ;  
	private ArrayAdapter<String> listAdapter ; 
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_friend_list); 

		// Find the ListView resource.   
		mainListView = (ListView) findViewById( R.id.friendsListView );  

		// Create and populate a List of planet names.  
		String[] planets = new String[] { "Mercury", "Venus", "Earth", "Mars",  
				"Jupiter", "Saturn", "Uranus", "Neptune"};    
		ArrayList<String> planetList = new ArrayList<String>();  
		planetList.addAll( Arrays.asList(planets) );  

		// Create ArrayAdapter using the planet list.  
		listAdapter = new ArrayAdapter<String>(this, R.layout.friends_row, planetList);  

		// Add more planets. If you passed a String[] instead of a List<String>   
		// into the ArrayAdapter constructor, you must not add more items.   
		// Otherwise an exception will occur.  
		listAdapter.add( "Ceres" );  
		listAdapter.add( "Pluto" );  
		listAdapter.add( "Haumea" );  
		listAdapter.add( "Makemake" );  
		listAdapter.add( "Eris" );  

		// Set the ArrayAdapter as the ListView's adapter.  
		mainListView.setAdapter( listAdapter );  
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.friend_list, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}  
 
 	


	/* transfer calls to other pages */
	public void jump_map(View view) {
		Intent intent = new Intent(this,MapActivity.class);
		startActivity(intent);
	}

	public void jump_friends(View view) {
		Intent intent = new Intent(this,FriendList.class);
		startActivity(intent);
	}

	public void jump_parts(View view) {
		Intent intent = new Intent(this,PartConfig.class);
		startActivity(intent);	
	}
	public void jump_settings(View view) {
		Intent intent = new Intent(this,HomeActivity.class);
		startActivity(intent);
	}
}
