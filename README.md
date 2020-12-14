# CassieAdvancedSettings
## Config
| Parameter | Type | Description |
| -------- | --- | -------- |
| is_enabled | bool | Should plugin be enabled (`true` or `false`) |
| cassies | List\<CassieInfo\> | List of custom cassies |
### CassieInfo
| Parameter | Type | Description |
| -------- | --- | -------- |
| trigger | string | Name of trigger, which fires cassies |
| value | string | Format string |
| glitch_chance | float | Chance of appearing .g |
| jam_chance | float | Chance of appearing .jam |
### Triggers
| Trigger | Description |
| ------- | -------- |
| OnNtfArrived  | MTF arrival |
| OnScp173Death | SCP-173's death |
| OnScp106Death | SCP-106's death |
| OnScp049Death | SCP-049's death |
| OnScp079Death | SCP-079's death |
| OnScp096Death | SCP-096's death |
| OnScp939Death | SCP-939's death |
### Keyphrases
| Keyphrase | Description | Context |
| -------------- | -------- | -------- |
| `{scpsleft}`   | Live scps count | All triggers |
| `{damagetype}` | SCP termination cause | SCP' death |
| `{mtf}`        | MTF unit name | MTF arrival |
### Config example
```yaml
CassieAdvancedSettings:
  # Should plugin be enabled.
  is_enabled: true
  # Custom cassies.
  cassies:
  - trigger: OnNtfArrived
    value: '{mtf} forcered'
    glitch_chance: 0.5
    jam_chance: 0.5
```