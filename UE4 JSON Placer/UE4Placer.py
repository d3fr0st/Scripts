import unreal
import json
import os

source = os.path.expandvars('%userprofile%\Desktop\example.json') # TODO look through folder structure
assetFolder = '/Game/Assets/'

with open(source) as data_file:
    data = json.load(data_file)

    for object in data:
        objectFound = unreal.EditorAssetLibrary.load_asset(assetFolder + object['name'])
        if objectFound:
            location = unreal.Vector()
            location.x = object['locx']
            location.y = object['locy']
            location.z = object['locz']
            rotation = unreal.Rotator()
            spawned_actor = unreal.EditorLevelLibrary.spawn_actor_from_object(objectFound, location, rotation)